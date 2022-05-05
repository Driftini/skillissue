using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Windows.Forms;

namespace SkillIssue
{
    public partial class frmActorDebug : Form
    {
        string[] ACTORS =
        {
            "Player",
            "Collider",
            "ZIndexTester"
        };

        void PopulateComboboxes()
        {
            foreach (string i in ACTORS)
            {
                cbActorType.Items.Add(i);
            }

            cbActorZIndex.Items.Add(Actor.eZINDEX.BACKGROUND);
            cbActorZIndex.Items.Add(Actor.eZINDEX.ENTITY);
            cbActorZIndex.Items.Add(Actor.eZINDEX.PLAYER);
            cbActorZIndex.Items.Add(Actor.eZINDEX.PARTICLE);
            cbActorZIndex.Items.Add(Actor.eZINDEX.SOLID);
            cbActorZIndex.Items.Add(Actor.eZINDEX.HUD);

            cbActorType.SelectedIndex = 0;
            cbActorZIndex.SelectedIndex = 0;
        }

        public string ReturnActorType()
        {
            return cbActorType.SelectedItem.ToString();
        }

        public Point ReturnActorPosition()
        {
            var p = new Point((int)nudActorPosition_X.Value, (int)nudActorPosition_Y.Value);
            return p;
        }

        public frmActorDebug()
        {
            InitializeComponent();
        }

        private void frmActorDebug_Load(object sender, EventArgs e)
        {
            PopulateComboboxes();
            Validate();
        }

        private void Validate(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls) {
                if (c is NumericUpDown || c is ComboBox && !(c.Name == "cbActorType"))
                    c.Enabled = false;
            }

            switch (cbActorType.SelectedItem.ToString())
            {
                case "Player":
                    nudActorPosition_X.Enabled = true;
                    nudActorPosition_Y.Enabled = true;
                    break;
                case "Collider":
                    nudActorPosition_X.Enabled = true;
                    nudActorPosition_Y.Enabled = true;
                    nudActorSize_X.Enabled = true;
                    nudActorSize_Y.Enabled = true;
                    break;
                case "ZIndexTester":
                    nudActorPosition_X.Enabled = true;
                    nudActorPosition_Y.Enabled = true;
                    nudActorSize_X.Enabled = true;
                    nudActorSize_Y.Enabled = true;
                    cbActorZIndex.Enabled = true;
                    nudActorSpeed.Enabled = true;
                    nudZITesterMoveTarget.Enabled = true;
                    break;
            }
        }
    }
}
