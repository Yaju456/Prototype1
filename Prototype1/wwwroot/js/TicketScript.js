var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Ticket/getshows' },
        "columns": [
            {
                data: 'showDate', "render": function (data) {

                    return `<div class="from-group" >
                  
                    ${data.slice(0, 10)}
                    </div>`
                }, "width": "15%"
            },
            {
                data: 'totalTickets', "width": "15%"
            },
            { data: 'soldTickets', "width": "15%" },
            { data: 'time', "width": "15%" },
            { data: 'show.name', "width": "15%" },

            {
                data: 'id',
                "render": function (data) {

                    return `<div class="from-group btn-group" role="group">
                    <a href="/Ticket/EnterShow?id=${data}" class="btn btn-primary  mx-1 btn-sm">Edit</a>
                    <a OnClick=Delete('/Ticket/Delete/${data}') class="btn btn-danger mx-1 btn-sm">Delete</a>
                    <a href="/Date/TicketData?id=${data}" class="btn btn-success mx-1 btn-sm">Create</a>
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
