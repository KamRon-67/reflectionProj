using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace reflectionProj
{
     public class Worker
    {
        IEmployee _CurrentEmployee;

        public Worker (IEmployee CurrentEmployee)
        {
            _CurrentEmployee = CurrentEmployee;
        }

        public void RearWork()
        {
            switch(_CurrentEmployee.EmployeeClass)
            {
                case EnumEmployeeClass.CFO:
                {
                        CFO MyCFO = new CFO();
                        MyCFO.Quits();
                }
                break;
                case EnumEmployeeClass.ProjectManager:
                    {
                        ProjectManager MyProjectManager = new ProjectManager();
                        MyProjectManager.Quits();
                    }
                    break;
                case EnumEmployeeClass.QA:
                    {
                        _CurrentEmployee.Work();
                    }
                break;
                case EnumEmployeeClass.Coder:
                    {
                        _CurrentEmployee.Work();
                    }
                    break;
                case EnumEmployeeClass.BA:
                    {
                        _CurrentEmployee.Work();
                    }
                    break;
            }
        }
    }
}