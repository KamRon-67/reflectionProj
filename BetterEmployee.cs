using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace reflectionProj
{
    public class BetterEmployee
    {
       
        IEmployee _CurrentEmployee;

        public BetterEmployee(IEmployee CurrentEmployee)
        {
            _CurrentEmployee = CurrentEmployee;
        }

        public void RearWork()
        {
            var EmployeeType = _CurrentEmployee.GetType();

            MethodInfo QuitsMethodInfo = EmployeeType.GetMethod("Quits");

            if (QuitsMethodInfo == null)
            {
                _CurrentEmployee.Work();
            }
            else
            {
                object QuitsEmployeeInstance = Activator.CreateInstance(EmployeeType, null);
                QuitsMethodInfo.Invoke(QuitsEmployeeInstance, null);
            }


        }
    }
    
}