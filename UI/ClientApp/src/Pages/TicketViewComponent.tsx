import React, { PureComponent } from 'react';
import { TicketListItemModel } from '../Components/TicketList/TicketListItemModel';
import { reviver } from '../json-parser';
import TicketList from '../Components/TicketList/TicketList';
import LoadingIndicator from '../Components/LoadingIndicator/LoadingIndicator';
import ErrorToast from '../Components/Toasts/ErrorToast';

interface Props {
    url: string,
    title: string
}

export default class TicketViewComponent extends PureComponent<Props> {

    readonly state = {
        isLoaded: false,
        tickets: [],
        error: null
    }

    componentDidMount() {

        fetch(this.props.url)
            .then(res => res.text().then(s => JSON.parse(s, reviver)))             
            .then(
            (result: TicketListItemModel[]) => {
                this.setState({
                    isLoaded: true,
                    tickets: result,
                    error: null
                });
            },
            (error) => {
                this.setState({
                    isLoaded: true,
                    error
                });
            }); 
    }
    
    render() {
        return (<div>
            <h1>{this.props.title}</h1>
            {!this.state.isLoaded && <LoadingIndicator />} 
            {this.state.isLoaded && this.state.error && <ErrorToast header="Unknown error" body="Could not load data." />} 
            {this.state.isLoaded && !this.state.error && <TicketList tickets={this.state.tickets} />}   
        </div>)
    }
}