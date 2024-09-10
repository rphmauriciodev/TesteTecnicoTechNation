import { drawLineChart } from '../Charts/lineChart.js';
import { mesDefault } from './utils.js';

export function renderReceitaChart(receitas) {
    const data = [
        ['Mês', 'Valor de Receita'],
    ];
    const mesMap = mesDefault.map(item => ({ ...item }));

    receitas.forEach(receita => {
        const mes = mesMap.find(item => item.id === receita.mes_pagamento);
        if (mes) {
            mes.valor = receita.total_receita;
        }
    });

    mesMap.forEach(item => {
        data.push([item.nome, item.valor]);
    });
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(() => drawLineChart('#receitaChart', data, 'Receita'));

}