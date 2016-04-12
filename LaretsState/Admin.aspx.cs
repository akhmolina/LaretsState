using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaretsState
{
    public partial class Admin : System.Web.UI.Page
    {
        public actualState actualState;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                MultiView.ActiveViewIndex = 0;
            }

            actualState = state.actualState;

            if (actualState.state == serviceState.OnService)
                { StateLabel.Text = "Сейчас сервис недоступен, ведутся технические работы."; }
                else
                {
                    StateLabel.Text = "Все работает штатно.";
                    serviceRecord next = actualState.nextRecord;
                    if (next != null)
                    { PlanLabel.Text = "На " + next.serviceStart.ToString("dd.MM.yyyy") + " запланированы работы."; }
                    else
                    { PlanLabel.Text = "Работы по обновлению не ведутся."; }
                }
            
        }

        protected void NextDate_SelectionChanged(object sender, EventArgs e)
        {
            NextDateLabel.Text = NextDate.SelectedDate.ToString("dd.MM.yyyy");
        }

        protected void PlanButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            DateTime selected = NextDate.SelectedDate.Date;
            string[] starttime = NextTime.Text.Split(':');
            string durationtime = Duration.Text;

            TimeSpan duration, start;
            try
            { start = new TimeSpan(int.Parse(starttime[0]), int.Parse(starttime[1]), 0); }
            catch
            { PlanStatus.Text = "Ошибка создания даты"; return; }

            selected = selected.Add(start);

            try
            { duration = new TimeSpan(0, int.Parse(durationtime), 0); }
            catch
            { PlanStatus.Text = "Ошибка создания даты"; return; }

            if (selected < DateTime.Now)
            { PlanStatus.Text = "Выбранная плановая дата раньше сегодняшней"; return; }

            try
            {
                state.addRecord(selected, duration);
                PlanStatus.Text = "Запись сохранена";
            }
            catch (Exception ex)
            { PlanStatus.Text = ex.Message; }

            Response.Redirect(Request.Path);
        }


        protected void PlanLinkButton_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 0;
        }

        protected void ShowAllLinkButton_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
        }

        protected void UpdateLinkButton_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 2;
        }

        protected void LogOutLinkButton_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}
