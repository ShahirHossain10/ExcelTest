$(document).ready(function () {
    PatientsSummaryDetail.Initial();

});


PatientsSummaryMaster = {
    GetAllPatients: function () {
        var res = [];

        $.ajax({
            async: false,
            type: 'GET',
            url: `https://localhost:44314/api/patient/getall`,
            success: function (result) {
                res = result;
            },
            error: function (error) {
                alert(error);
            }
        });
        return res;

    },

    GetBill: function () {
        var res = [];
        $.ajax({
            async: false,
            type: "Get",
            url: " http://localhost:5025/api/Bill/GetAllBill",
            success: function (data) {
                res = data;
            },
            error: function (error) {
                alert(error);
            }
        });
        return res;
    },
    GetDelete: function (id) {
        $.ajax({
            async: false,
            type: "Delete",
            url: "https://localhost:44314/api/patient/Delete?id=" + id,
            success: function (res) {
                $("#tblBody").empty();
                PatientsSummaryDetail.Initial();
                debugger;
                alert(res.message);
            },
            error: function (error) {
                alert(error);
            }
        });
        //    return res;
    }
};

PatientsSummaryDetail = {
    Initial: function () {
        var patients = PatientsSummaryMaster.GetAllPatients();
        debugger;
        var res = [];
        for (var i = 0; i < patients.length; i++) {
            res.push("<tr><td>" + patients[i].name + "</td><td>" + patients[i].dieaseName + "</td><td>" + patients[i].epilepsy + "</td><td><a class='btn btn-info' href='../patient/details/" + patients[i].id + "'> Details</a><a class='btn btn-warning' href='../patient/edit/" + patients[i].id + "' >Edit</a><button class='btn btn-danger' onclick='PatientsSummaryDetail.Delete(" + patients[i].id + ")'>Delete</button></td></tr>");
        }
        $("#tblBody").append(res);
    },
    Delete: function (id) {
        PatientsSummaryMaster.GetDelete(id);
    },
};