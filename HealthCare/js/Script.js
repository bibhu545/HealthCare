$(document).ready(function () {
    $("#btnCreatePhone").click(function () {
        $(".phoneNumbers").append(
            "<input class='form-control phone delete-phone' placeholder='Enter phone number' type='text'/>"
        );
    });

    function collectPhoneNumbers() {
        var all_phone = "";
        $('.phone').each(function () {
            all_phone = all_phone + $(this).val() + ";";
        });
        $("#txtPhone").val(all_phone);
    }


    $("#btnSaveData, #btnUpdateData").click(function () {
        collectPhoneNumbers();

        var userName = $('#txtUserName').val();
        var firstName = $('#txtFirstName').val();
        var lastName = $('#txtLastName').val();
        var address = $('#txtAddress').val();

        var validFlag = true;
        if (userName == "") {
            validFlag = false;
            $('#txtUserName').addClass('invalid');
        }
        if (firstName == "") {
            validFlag = false;
            $('#txtFirstName').addClass('invalid');
        }
        if (lastName == "") {
            validFlag = false;
            $('#txtLastName').addClass('invalid');
        }
        if (address == "") {
            validFlag = false;
            $('#txtAddress').addClass('invalid');
        }
        if (!validFlag) {
            alert("Please fill all fields.");
            return false;
        }
    });

    $('.btn-danger').click(function () {
        if (!window.confirm('Are you sure?')) {
            return false;
        }
    });

    var rowNumber = -1;
    $(document).on('click', '.btn-edit', (function () {

        $('#txtUserName, #txtFirstName, #txtLastName, #txtAddress').removeClass('invalid');
        $('.btn-editUser').show();
        $('.btn-addUser').hide();
        $('.txt-default').hide();
        $('.delete-phone').remove();

        var userId = $(this).closest('tr').find('td:eq(0)').text();
        $("#hiddenUserId").val(userId);
        rowNumber = $(this).closest('tr').index();
        var userName = $(this).closest('tr').find('td:eq(1)').text();
        $('#txtUserName').val(userName);
        var firstName = $(this).closest('tr').find('td:eq(2)').text();
        $('#txtFirstName').val(firstName);
        var lastName = $(this).closest('tr').find('td:eq(3)').text();
        $('#txtLastName').val(lastName);
        var address = $(this).closest('tr').find('td:eq(4)').text();
        $('#txtAddress').val(address);

        $(this).closest('tr').find('td:eq(5)').find('span').each(function () {
            $('.phoneNumbers').append(
                "<input class='form-control phone delete-phone' value='" + $(this).text() + "' type='text'/>"
            );
        });
    }));

    $('.close .close-popup').click(function () {
        $('.delete-phone').remove();
        $('.btn-addUser').show();

        $('.txt-default').show();
        $('#txtUserName').val("");
        $('#txtFirstName').val("");
        $('#txtLastName').val("");
        $('#txtAddress').val("");
    });

    $('.add-user').click(function () {
        $('#txtUserName,#txtFirstName,#txtLastName,#txtAddress').removeClass('invalid');
        $('.btn-editUser').hide();
        $('.btn-addUser').show();
        $('.delete-phone').remove();

        $('.txt-default').show();
        $('#txtUserName').val("");
        $('#txtFirstName').val("");
        $('#txtLastName').val("");
        $('#txtAddress').val("");
    });

});