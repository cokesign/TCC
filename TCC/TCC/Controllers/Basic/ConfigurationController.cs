using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCC.Models;
using TCC.ViewModels;

namespace TCC.Controllers.Basic
{
    public class ConfigurationController : Controller
    {
        private Entities db = new Entities();

        public async Task<ActionResult> Edit(int? id)
        {
            Configuration configuration = await db.Configuration.FindAsync(1);

            var config = GetTipoRega(configuration);

            return View(config);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Timer,Minutes,Schedule,Time,Garden")] ConfigurationViewModel configuration)
        {
            if (ModelState.IsValid)
            {
                if (!(await db.Configuration.FirstOrDefaultAsync() is Configuration config)) { 
                    config = new Configuration()
                    {
                        Garden = false,
                        Minutes = null,
                        Schedule = false,
                        Time = null,
                        Timer = false
                    };

                    db.Configuration.Add(config);
                }
                else
                {
                    config = SetTipoRega(config, configuration.TipoRega, configuration.Value);
                    db.Entry(config).State = EntityState.Modified;
                }
                
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(configuration);
        }

        private Configuration SetTipoRega(Configuration config, TipoRega tipo, Object value)
        {
            switch (tipo)
            {
                case TipoRega.Garden:
                    config.Timer = false;
                    config.Minutes = null;
                    config.Schedule = false;
                    config.Time = null;
                    config.Garden = true;
                    break;
                case TipoRega.Schedule:
                    config.Timer = false;
                    config.Minutes = null;
                    config.Schedule = true;
                    config.Time = (DateTime)value;
                    config.Garden = false;
                    break;
                case TipoRega.Timer:
                    config.Timer = true;
                    config.Minutes = (int)value;
                    config.Schedule = false;
                    config.Time = null;
                    config.Garden = false;
                    break;
            }
            return config;
        }

        private ConfigurationViewModel GetTipoRega(Configuration config)
        {
            var viewModel = new ConfigurationViewModel();
            if (config.Garden)
            {
                viewModel.TipoRega = TipoRega.Garden;
                viewModel.Value = null;
            }

            if (config.Schedule)
            {
                viewModel.TipoRega = TipoRega.Schedule;
                viewModel.Value = config.Time.ToString();
            }

            if (config.Timer)
            {
                viewModel.TipoRega = TipoRega.Timer;
                viewModel.Value = config.Minutes.ToString();
            }
            return viewModel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
