import React from 'react';
import Toast from 'react-bootstrap/Toast';

interface Props {
    header: string,
    body: string
}

const ErrorToast: React.FunctionComponent<Props> = (props) => {
    return <Toast
        style={{
            position: 'absolute',
            top: 0,
            right: 0,
        }}
    >
        <Toast.Header>
            <img src="holder.js/20x20?text=%20" className="rounded mr-2" alt="" />
            <strong className="mr-auto">Error!</strong>
            <small>props.header</small>
        </Toast.Header>
        <Toast.Body>props.body</Toast.Body>
    </Toast>
}

export default ErrorToast;