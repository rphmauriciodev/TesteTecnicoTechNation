export function drawLineChart(elementId, dataTable, title) {
    const data = google.visualization.arrayToDataTable(dataTable);

    const options = {
        title: title,
        curveType: 'function',
        legend: { position: 'bottom' }
    };

    const chart = new google.visualization.LineChart(document.getElementById(elementId));
    chart.draw(data, options);
}
