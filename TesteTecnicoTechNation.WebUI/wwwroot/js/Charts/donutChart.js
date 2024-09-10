export function drawDonutChart(elementId, dataTable, title) {
    const data = google.visualization.arrayToDataTable(dataTable);

    const options = {
        title: title,
        pieHole: 0.4
    };

    const chart = new google.visualization.PieChart($(elementId).get(0));
    chart.draw(data, options);
}