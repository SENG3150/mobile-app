/*
    *   Title:          SubAssemblyView
    *   Purpose:        Is a CarouselPage where a user can swipe between each test for a sub assembly
    *   Last Updated:   20/05/16
*/

using MachineMaintenance.Inspections;
using Xamarin.Forms;

namespace MachineMaintenance
{
    internal class SubAssemblyView : CarouselPage
    {
        private SubAssembly subA;

        public SubAssemblyView(SubAssembly subA)
        {
            this.subA = subA;
            subAssemController();
        }

        private void subAssemPresentation()
        {
            Title = subA.subAssembly.name;

            foreach (MachineMaintenance.ObjectModel.Test test in subA.subAssembly.tests)
            {
                if (test.oil.test)
                {
                    Children.Add(new OilTestView(subA.oilTest));
                }

                if (test.wear.test)
                {
                    Children.Add(new WearTestView(subA.wearTest));
                }

                if (test.machineGeneral.test)
                {
                    Children.Add(new MachineGeneralTestView(subA.machineGeneralTest));
                }
            }

        }

        private void subAssemController()
        {
            subAssemPresentation();
        }
    }
}