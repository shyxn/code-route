using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_route
{
    public class Controller
    {
        private Model _model;

        public Controller(Model model)
        {
            this._model = model;
            // Test
            this._model.ReadAllTable();
        }
    }
}
