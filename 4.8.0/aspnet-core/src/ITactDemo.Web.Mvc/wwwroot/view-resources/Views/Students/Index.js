(function () {
    $(function () {
        var _studentService = abp.services.app.student;

        $('#CreateNewStudent').click(function () {
            window.location.href = "/Students/CreateOrEditStudent"
        });

        function editStudent(id) {
            if (id > 0) {
                window.location.href = "/Students/CreateOrEditStudent?id=" + id;
            }
            else {
                window.location.href = "/Students/CreateOrEditStudent";
            }
        }
        
        function deleteStudent(id) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('Deletestudent', 'ITactDemo')),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _studentService.deleteStudent({ id: id }).done(function () {
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                            jQuery(grid_selector).trigger("reloadGrid");
                        });
                    }
                }
            );
        }
        
        var grid_selector = "#student";
        var pager_selector = "#studentPager";
        var grid_url = "/Students/GetStudent";

        jQuery(grid_selector).jqGrid({
            url: grid_url,
            sortname: "id",
            colNames: ["FirstName", "LastName", "Email", "PhoneNumber", "BirthDate", "Gender", "Hobby", "Id", "Student Photo", "Action"],
            colModel: [
                {
                    name: "firstName", index: "firstName", search: true, width: 100
                },
                {
                    name: "lastName", index: "lastName", search: true, width: 100
                },
                {
                    name: "email", index: "email", search: true, width: 100
                },
                {
                    name: "phoneNumber", index: "phoneNumber", search: true, width: 100
                },
                {
                    name: "birthDate", index: "birthDate", search: true, width: 150, formatter: dateFormatter,
                    searchoptions: {
                        sopt: ['eq'],
                        dataInit: function (elem) {
                            $(elem).datepicker({
                                singleDatePicker: true,
                                autoclose: true,
                                showDropdowns: true,
                                autoUpdateInput: false
                            }).on('apply.datepicker', function (ev, picker) {
                                $(this).val(picker.startDate.format('L'));
                                $(this).keydown();
                            });
                        }
                    }
                },
                {
                    name: "gender", index: "gender", search: true, width: 150
                },
                {
                    name: "hobbies", index: "hobbies", search: true, width: 150
                },
                { name: "id", index: "id", hidden: true, key: true },
                {
                    name: 'studentImage', index: 'studentImage', formatter: imageFormatter, sortable: false, width: 150, align: "center", search: false, width: 150
                },
                {
                    name: 'actions', index: 'id', formatter: actionFormatter, sortable: false, width: 150, align: "center", search: false, width: 75
                }

            ],
            pager: pager_selector,
            height: "auto",
            width:"auto",

            loadComplete: function () {
                
                jQuery(grid_selector).trigger('resize');
                $(grid_selector).jqGrid('setGridWidth', $(grid_selector).closest(".jqgrid").width());

                $(grid_selector + ' .btnEdit').click(function () {
                    editStudent($(this).data().id);
                });

                $(grid_selector + ' .btnDelete').click(function () {
                    deleteStudent($(this).data().id);
                });
            }
        });
        jQuery(grid_selector).navGrid(pager_selector, jgridNavOpt);
        jQuery(grid_selector).jqGrid('filterToolbar', jgridFilterOpt);

        function actionFormatter(cellvalue, options, rowObject) {
            var actions = "";
            actions += "<button class='btn btn-xs btn-success btnEdit' data-id='" + rowObject['id'] + " 'tooltip=Edit'><i class='fa fa-edit'></i></button>&nbsp; ";
            actions += "<button class='btn btn-xs btn-danger btnDelete' data-id='" + rowObject['id'] + "'tooltip='Delete'><i class='fa fa-remove'></i></button>";
            return actions;
        }

        function imageFormatter(cellvalue, options, rowObject) {
            var actions = "";
            if (cellvalue != null && cellvalue != "" && cellvalue != undefined)
                actions = "<img src=" + cellvalue + " height=50/>";
            return actions;
        }

        function dateFormatter(cellvalue, options, rowObject) {
            
            if (cellvalue !== null && cellvalue !== "") {

                return moment(cellvalue).format('L');
            }
            else {
                return "";
            }
        }
        
    });
})();
