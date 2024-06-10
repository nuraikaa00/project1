﻿using Microsoft.EntityFrameworkCore;
using sweet_shop.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweet_shop
{

    internal static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SecondModuleContext context = new SecondModuleContext();
            
            Application.Run(new frmLogin(context));
        }
    }
}
