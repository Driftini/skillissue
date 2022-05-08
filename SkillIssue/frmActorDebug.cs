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

        private void ValidateInput(object sender, EventArgs e)
        {
            if (cbActorType.SelectedIndex > -1 && cbActorZIndex.SelectedIndex > -1)
            {
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is NumericUpDown && c.Name != "nudSpawnCount" || c is ComboBox && c.Name != "cbActorType")
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

                btAddActor.Enabled = true;
            }
            else
                btAddActor.Enabled = false;
        }

        #region Return methods

        public Button ReturnSpawnButton()
        {
            return btAddActor;
        }
        public Button ReturnRemoveButton()
        {
            return btRemoveActor;
        }

        public string ReturnActorType()
        {
            return cbActorType.SelectedItem.ToString();
        }

        public Point ReturnActorPosition()
        {
            return new Point((int)nudActorPosition_X.Value, (int)nudActorPosition_Y.Value);
        }

        public Size ReturnActorSize()
        {
            return new Size((int)nudActorSize_X.Value, (int)nudActorSize_Y.Value);
        }

        public float ReturnActorSpeed()
        {
            return (float)nudActorSpeed.Value;
        }

        public Actor.eZINDEX ReturnActorZIndex()
        {
            switch (cbActorZIndex.SelectedItem.ToString())
            {
                case "BACKGROUND":
                    return Actor.eZINDEX.BACKGROUND;
                case "PLAYER":
                    return Actor.eZINDEX.PLAYER;
                case "PARTICLE":
                    return Actor.eZINDEX.PARTICLE;
                case "SOLID":
                    return Actor.eZINDEX.SOLID;
                case "HUD":
                    return Actor.eZINDEX.HUD;
                default:
                    return Actor.eZINDEX.ENTITY;
            }
        }

        public int ReturnZITesterMoveTarget()
        {
            return (int)nudZITesterMoveTarget.Value;
        }

        public int ReturnSpawnCount()
        {
            return (int)nudSpawnCount.Value;
        }

        public int ReturnRemoveID()
        {
            return (int)nudRemoveID.Value;
        }

        #endregion

        public frmActorDebug()
        {
            InitializeComponent();
        }

        private void frmActorDebug_Load(object sender, EventArgs e)
        {
            PopulateComboboxes();
            Validate();
        }
    }
}
