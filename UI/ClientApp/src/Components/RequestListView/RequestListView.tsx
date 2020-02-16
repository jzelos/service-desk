import React, { PureComponent } from 'react';
import { RequestItem } from './RequestItem';
import BootstrapTable, { Column } from 'react-bootstrap-table-next';
import filterFactory, { dateFilter, textFilter, numberFilter } from 'react-bootstrap-table2-filter';
import 'react-bootstrap-table2-filter/dist/react-bootstrap-table2-filter.min.css';

// https://examples.bootstrap-table.com/#welcomes/from-data.html
// https://react-bootstrap.github.io/components/spinners/ - looks very good

interface Props {
    tickets: RequestItem[], 
    onRowSelected?: (row: RequestItem) => void 
}

export default class RequestListView extends PureComponent<Props> {

    dateFormatter = (cell: Date, row: RequestItem, rowIndex: number, formatExtraData: any) => {
        return cell.toDateString();      
    }

    columns = [{
        dataField: 'id',
        text: 'Ticket ID',
        sort: true,
        filter: numberFilter()
    }, {
        dataField: 'createdDate',
        type:'date',
        text: 'Date Created',
        sort: true, 
        formatter: this.dateFormatter,
        filter: dateFilter()
    }, {
        dataField: 'assignee',
        text: 'Assignee',
        sort: true,
        filter: textFilter()
    },
    {
        dataField: 'status',
        text: 'Status',
        sort: true,
        filter: textFilter()
    },
    {
        dataField: 'summary',
        text: 'Summary',
        sort: true,
        filter: textFilter()
    }];

    selectRow = {
        mode: 'checkbox',
        onSelect: (row: RequestItem, isSelect: boolean, rowIndex: number, e: any) => {            
            if (this.props.onRowSelected)
                this.props.onRowSelected(row);            
            return false;             
        }, 
        clickToSelect: true,
        hideSelectColumn: true
      };


    render() {
        return (<BootstrapTable 
            bootstrap4={true} 
            striped={false} 
            bordered={true} 
            hover={true}
            selectRow={this.selectRow}
            keyField='id' 
            data={this.props.tickets} 
            columns={this.columns as Column[]} 
            filter={ filterFactory()} />)
    }
}