var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Date/getall' },
        "columns": [
            {
                data: 'showTIcketsClass.showDate', "render": function (data) {

                    return `<div class="from-group" >
                  
                    ${data.slice(0, 10)}
                    </div>`
                }, "width": "15%"
            },
            {
                data: 'showTIcketsClass.showID', "width": "15%"
            },
            { data: 'showTIcketsClass.time', "width": "15%" },
            { data: 'ticketno', "width": "15%" },
            { data: 'checked', "width": "15%" },


            {
                data: 'id',
                "render": function (data) {

                    return `<div class="from-group btn-group" role="group">
                    <a href="/Date/Edit?id=${data}" class="btn btn-primary  mx-1 btn-sm">Edit</a>
                    </div>`
                },
                "width": "15%"
            }
        ]
    });
}


