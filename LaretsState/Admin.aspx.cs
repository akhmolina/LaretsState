using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaretsState
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NextDate.SelectedDate = DateTime.Now.Date;
            NextTime.Text = DateTime.Now.ToString("HH:mm");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            // todo
            LabelOutput.Text = "Запись сохранена.";
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime selected = NextDate.SelectedDate;
            var time = NextTime.Text.Split('\u0058');
            try
            {
                selected.Add(new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), 0));
            }
            catch  { args.IsValid = false; return; }

            if (selected > DateTime.Now)
            { args.IsValid = true; }
            else
            { args.IsValid = false; }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime selected = NextDate.SelectedDate;
            var time = NextTime.Text.Split('\u0058');
            try
            {
                selected.Add(new TimeSpan(int.Parse(time[0]), int.Parse(time[1]), 0));
            }
            catch { args.IsValid = false; return; }

            //todo
            args.IsValid = true;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }
    }
}