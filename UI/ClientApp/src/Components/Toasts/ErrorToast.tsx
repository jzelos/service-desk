import React, { useState } from 'react';
import Toast from 'react-bootstrap/Toast';

interface Props {
    header: string,
    body: string
}

const ErrorToast: React.FunctionComponent<Props> = (props) => {

    const [show, setShow] = useState(true);
    const toggleShow = () => setShow(!show);

    return <Toast 
        show={show} 
        onClose={toggleShow}
        style={{
            position: 'absolute',
            top: 0,
            right: 0,
        }}
    >
        <Toast.Header>
            <img src="holder.js/20x20?text=%20" className="rounded mr-2" alt="" />
            <strong className="mr-auto">{props.header}</strong>            
        </Toast.Header>
        <Toast.Body>{props.body}</Toast.Body>
    </Toast>
}

export default ErrorToast;