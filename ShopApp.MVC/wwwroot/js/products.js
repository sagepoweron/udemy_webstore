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
                { data: 'description'},
                { data: 'listPrice' },
                { data: 'salePrice' },
                { data: 'imageUrl'}
            ]
        }
    );
}

