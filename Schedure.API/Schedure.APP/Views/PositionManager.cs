using DevComponents.DotNetBar;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedure.APP.Views
{
    public class PositionManager
    {
        public PositionDTO Position { get; set; }
        public List<ButtonWithPosition> lstBtn { get; set; }
        public List<ControlWithPosition> lstControl { get; set; }

        public PositionManager()
        {
            lstBtn = new List<ButtonWithPosition>();
            lstControl = new List<ControlWithPosition>();
        }

        public void AddButton(ButtonItem button, Func<PositionDTO, bool?> funCheck)
        {
            lstBtn.Add(new ButtonWithPosition(button, funCheck));
        }

        public void AddControl(Control control, Func<PositionDTO, bool?> funCheck)
        {
            lstControl.Add(new ControlWithPosition(control, funCheck));
        }

        public void SetEnable()
        {
            lstBtn.ForEach(item => item.SetEnable(Position));
            lstControl.ForEach(item => item.SetEnable(Position));
        }

        public class ButtonWithPosition
        {
            public ButtonItem Button { get; set; }
            public Func<PositionDTO, bool?> funCheck { get; set; }

            public ButtonWithPosition(ButtonItem Button, Func<PositionDTO, bool?> funCheck)
            {
                this.Button = Button;
                this.funCheck = funCheck;
            }

            public void SetEnable(PositionDTO position)
            {
                Button.Enabled = funCheck.Invoke(position) == true;
            }
        }

        public class ControlWithPosition
        {
            public Control Control { get; set; }
            public Func<PositionDTO, bool?> funCheck { get; set; }

            public ControlWithPosition(Control control, Func<PositionDTO, bool?> funCheck)
            {
                this.Control = control;
                this.funCheck = funCheck;
            }

            public void SetEnable(PositionDTO position)
            {
                Control.Enabled = funCheck.Invoke(position) == true;
            }
        }
    }


}
