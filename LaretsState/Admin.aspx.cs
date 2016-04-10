﻿using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["actualState"] == null)
            { Application["actualState"] = state.Instance; }

            state actualState = (state)Application.Get("actualState");

            if (actualState.actualState == serviceState.OnService)
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

            NextDateLabel.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");
            NextDate.SelectedDate = DateTime.Now.Date;
            NextTime.Text = DateTime.Now.ToString("HH:mm");
            MultiView.ActiveViewIndex = 0;
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


            state actualState = (state)Application.Get("actualState");
            try
            {
                actualState.addRecord(new serviceRecord(selected, duration));
                PlanStatus.Text = "Запись сохранена";
            }
            catch (Exception ex)
            { PlanStatus.Text = ex.Message; }
            
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
