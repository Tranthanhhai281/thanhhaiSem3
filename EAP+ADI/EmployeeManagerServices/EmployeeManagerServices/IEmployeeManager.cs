using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeManagerServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeManager" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeManager
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/GetListEmployee"
            )]
        List<Employee> GetEmployees();


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/CreateEmployee"
            )]
        bool AddEmployee(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/EditEmployee/{id}"
            )]
        bool EditEmployee(string id, Employee employee);

        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/DeleteEmployee/{id}"
           )]
        bool DeleteEmployee(string id);


        //department
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/GetListDepartment"
           )]
        List<Department> GetDepartments();


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/CreateDepartment"
            )]
        bool AddDepartment(Department department);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/EditDepartment/{id}"
            )]
        bool EditDepartment(string id, Department department);

        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/DeleteDepartment/{id}"
           )]
        bool DeleteDepartment(string id);

    }
}
