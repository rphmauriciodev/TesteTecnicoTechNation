export function drawLineChart(elementId, dataTable, title) {
    const data = google.visualization.arrayToDataTable(dataTable);
    
    const options = {
        title: title,
        curveType: 'function',
        legend: { position: 'bottom' }
    };

    const chart = new google.visualization.LineChart($(elementId).get(0));
    chart.draw(data, options);
}
