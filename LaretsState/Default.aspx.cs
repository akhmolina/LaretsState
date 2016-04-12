using System;

namespace LaretsState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            actualState actualState = state.actualState;

            if (actualState != null && actualState.state == serviceState.OnService)
            {StateLabel.Text = "Сейчас сервис недоступен, ведутся технические работы."; }
            else
            {
                StateLabel.Text = "Все работает штатно.";
                serviceRecord next = null;
                if (actualState != null) next = actualState.nextRecord;

                if ( next!= null)
                {PlanLabel.Text = "На " + next.serviceStart.ToString("dd.mm.yyyy") + " запланированы работы."; }
                else
                { PlanLabel.Text = "Работы по обновлению не ведутся."; }

            }
        }
    }
}