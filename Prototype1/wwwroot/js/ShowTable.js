﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/show/MainShow' },
        "columns": [
            { data: 'name', "width": "15%" },
            {
                data: 'startDate', "render": function (data) {

                    return `<div class="from-group" >
                  
                    ${data.slice(0, 10)}
                    </div>`
                }, "width": "15%"
            },
            {
                data: 'endDate', "render": function (data) {

                    return `<div class="from-group" >
                  
                    ${data.slice(0, 10)}
                    </div>`
                }, "width": "15%" },
            {
                data: 'id',
                "render": function (data) {

                    return `<div class="from-group btn-group" role="group">
                    <a href="/show/Enter?id=${data}" class="btn btn-primary mx-2">Edit</a>
                    <a OnClick=Delete('/show/Delete/${data}') class="btn btn-danger mx-2">Delete</a> 
                    </div>`
                },
                "width": "15%"
            }
        ]
    });
}



function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })

        }
    })
}   