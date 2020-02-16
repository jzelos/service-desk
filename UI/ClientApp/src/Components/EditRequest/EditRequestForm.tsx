import React, { PureComponent } from 'react';
import { RequestItem } from './RequestItem';

interface Props {
    request: RequestItem,
    onClose: () => void
}

export default class EditRequestForm extends PureComponent<Props> {

    render() {
        return (
            <div>
                {this.props.request.id}
            </div>)
    }
}