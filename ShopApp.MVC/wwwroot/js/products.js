$(document).ready(
    function ()
    {
        LoadDataTable();
    }
);

function LoadDataTable() {
    data_table = $('#table_data').DataTable(
        {
            "ajax": { url: '/admin/products/getall' },
            "columns": [
                { data: 'category.name', "width": "15%" },
                { data: 'name' },
                { data: 'description', "width": "10%" },
                { data: 'listPrice', "width": "5%" },
                { data: 'salePrice', "width": "5%" },
                { data: 'imageUrl' },
                {
                    //url: '@Url.Action("Edit", "products")',
                    data: 'id',
                    "render": function (data) {
                        //return '<div>Hello</div>'
                        //return `<a asp-action="Edit" asp-route-id="@${data}">Edit</a>`
                        //return `
                        //<div class="w-75 btn-group" role="group">
                        //<a href="/admin/products/edit/${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>Edit</a>
                        //<a href="/admin/products/details/${data}" class="btn btn-primary mx-2"><i class="bi bi-info-square"></i>Details</a>
                        //<a href="/admin/products/delete/${data}" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
                        //</div>
                        //`
                        return `
                        <div class="w-50 btn-group" role="group">
                        <a href="/admin/products/edit/${data}" class="btn btn-primary mx-2">Edit</a>
                        <a href="/admin/products/details/${data}" class="btn btn-primary mx-2">Details</a>
                        <a href="/admin/products/delete/${data}" class="btn btn-danger mx-2">Delete</a>
                        </div>
                        `
                    },
                    "width": "15%"
                }
                
                
            ]
        }
    );
}

