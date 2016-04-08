using System;

namespace LaretsState
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            state actualState = (state)Application.Get("actualState");

            if (actualState != null && actualState.getActualState() == serviseState.OnService)
            {StateLabel.Text = "Сейчас сервис недоступен, ведутся технические работы."; }
            else
            {
                StateLabel.Text = "Все работает штатно.";
                serviseRecord next = null;
                if (actualState != null) next = actualState.getNextRecord();

                if ( next!= null)
                {PlanLabel.Text = "На " + next.serviceStart.ToString("dd.mm.yyyy") + " запланированы работы."; }
                else
                { PlanLabel.Text = "Работы по обновлению не ведутся."; }
            }
        }
    }
}