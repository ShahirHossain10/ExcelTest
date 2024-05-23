$(document).ready(function () {
    PatientDetail.Initial();
});
var gbDieaseList = ['<option value="">Select One</option>'];
var gbAllergieList = ['<option value="">Select One</option>'];
var gbNCDList = ['<option value="">Select One</option>'];


PatientMaster = {
    GetDisease: function () {
        var res = [];

        $.ajax({
            async: false,
            type: 'GET',
            url: `https://localhost:44314/api/Common/GetDiease`,
            success: function (result) {
                res = result;
            },
            error: function (error) {
                alert(error);
            }
        });
        return res;
    },
    GetAllergies: function () {
        var res = [];

        $.ajax({
            async: false,
            type: 'GET',
            url: `https://localhost:44314/api/Common/GetAllergies`,
            success: function (result) {
                res = result;
            },
            error: function (error) {
                alert(error);
            }
        });
        return res;
    },
    GetNCD: function () {
        var res = [];

        $.ajax({
            async: false,
            type: 'GET',
            url: `https://localhost:44314/api/Common/GetNCD`,
            success: function (result) {
                res = result;
            },
            error: function (error) {
                alert(error);
            }
        });
        return res;
    },
    SavePatient: function () {

        if (PatientDetail.ValidateObj()) {

            var patient = PatientDetail.CreateObject();

            $.ajax({
                async: false,
                type: "POST",
                contentType: "application/json",
                url: " https://localhost:44314/api/patient/post",
                data: JSON.stringify(patient),
                success: function (result) {
                    debugger;
                    alert('Successfully received Data ');
                    console.log(result);
                },
                error: function (error) {
                    debugger;
                    alert('Failed to receive the Data');
                    console.log('Failed ');
                }
            });
        }
    }
};
PatientDetail = {
    Initial: function () {
        $('#addNCD').click(function () {
            return !$('#select1 option:selected').remove().appendTo('#select2');
        });
        $('#removeNCD').click(function () {
            return !$('#select2 option:selected').remove().appendTo('#select1');
        });
        $('#addAllergie').click(function () {
            return !$('#select3 option:selected').remove().appendTo('#select4');
        });
        $('#removeAllergie').click(function () {
            return !$('#select4 option:selected').remove().appendTo('#select3');
        });
        $('#btnSave').click(function () {
            PatientMaster.SavePatient();
        });

        PatientDetail.SetDropDownValue();

    },

    SetDropDownValue: function () {
        var dieaseList = PatientMaster.GetDisease();
        for (var i = 0; i < dieaseList.length; i++) {
            gbDieaseList.push("<option value=" + dieaseList[i].id + ">" + dieaseList[i].name + "</option>");
        }
        $('#diseaseId').append(gbDieaseList);

        var allergieList = PatientMaster.GetAllergies();
        for (var i = 0; i < allergieList.length; i++) {
            gbAllergieList.push("<option value=" + allergieList[i].id + ">" + allergieList[i].name + "</option>");
        }
        $('#select3').append(gbAllergieList);

        var ncdList = PatientMaster.GetNCD();
        for (var i = 0; i < ncdList.length; i++) {
            gbNCDList.push("<option value=" + ncdList[i].id + ">" + ncdList[i].name + "</option>");
        }
        $('#select1').append(gbNCDList);

    },
    ValidateObj: function () {
        var res = true;
        var messsage = "";
        var name = $("#name").val();
        if (name == "" || name == null) {
            messsage += "Name is Required.\n";
            res = false;
        }
        var diseaseId = parseInt($("#diseaseId").val());
        if (diseaseId == null || diseaseId == 0 || diseaseId == "") {
            messsage += "Diease is Required.\n";
            res = false;
        }
        var diseaseId = parseInt($("#diseaseId").val());
        if (diseaseId == null || diseaseId == 0 || diseaseId == "") {
            messsage += "Diease is Required.\n";
            res = false;
        }

        var selectedAllergie = [];
        $("#select4 option").each(function () {

            var value = parseInt($(this).val());
            selectedAllergie.push(value);
        });
        if (selectedAllergie.length <= 0) {
            messsage += "Select at least one option from Allergie dropdown.";
            res = false;
        }
        if (res == false)
            alert(messsage);
        return res;
    },

    CreateObject: function () {

        var obj = {};
        var selectedNCD = [];
        var selectedAllergie = [];
        obj.Name = $("#name").val().trim();
        obj.DieaseId = parseInt($("#diseaseId").val());
        obj.HasEpilepsy = parseInt($("#hasEpilepsy").val());
        $("#select2 option").each(function () {
            var value = parseInt($(this).val());
            selectedNCD.push(value);
        });
        $("#select4 option").each(function () {

            var value = parseInt($(this).val());
            selectedAllergie.push(value);
        });

        obj.NCDs = selectedNCD;
        obj.Allergies = selectedAllergie;
        return obj;
    }

};