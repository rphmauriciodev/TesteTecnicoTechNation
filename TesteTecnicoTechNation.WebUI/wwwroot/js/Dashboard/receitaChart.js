import { drawLineChart } from '../Charts/lineChart.js';

const data = [
    ['Mês', 'Valor da Receita'],
    ['Janeiro', 1000],
    ['Fevereiro', 1170],
    ['Março', 660],
    ['Abril', 1030]
];

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(() => drawLineChart('receitaChart', data, 'Receita'));
