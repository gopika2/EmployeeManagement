

$(document).ready(function () {
    bindEvents();
    hideEmployeeDetailCard();
});

function bindEvents() {
    $(".employeeDetails").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/' + employeeId,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var newEmployeeCard = `<div class="card">
                                          <h1>${result.name}</h1>
                                         <b>Id :</b> <p>${result.id}</p>
                                         <b>Department:</b><p>${result.department}</p>
                                         <b>Age:</b><p>${result.age}</p>
                                         <b>Address:</b><p>${result.address}</p>
                                        </div>`

                $("#EmployeeCard").html(newEmployeeCard);
                showEmployeeDetailCard();
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $(".employeeDelete").on("click", function (event) {
        var employeeId = event.currentTarget.getAttribute("data-id");

        $.ajax({
            url: 'https://localhost:44383/api/internal/employee/deleteemployees/' + employeeId,
            type: 'DELETE',
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                location.reload();
                alert("Are you sure want to delete");
           
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    $("#btnSave").click(function(){
        var employee =  {
            employeeId: 0,
            name: $("#txtName").val(),
            department: $("#txtDepartment").val(),
            address: $("#txtAddress").val(),
            age: parseInt($("#txtAge").val())
        };
        console.log(employee);
        
        $.ajax({
            url: 'https://localhost:44383/employee/InsertEmployee',
            type: 'POST',
            data: JSON.stringify(employee),
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                console.log(result);
                if (result == true) {
                    alert("Employee added successfully");
                    location.reload();
                }
                else {
                    alert("Failed to add employee");

                }

            },
            error: function (error) {
                console.log(error);
                alert("Failed to add employee");
            }
        });
    });
}

 
function hideEmployeeDetailCard() {
    $("#EmployeeCard").hide();
}

function showEmployeeDetailCard() {
    $("#EmployeeCard").show();
}