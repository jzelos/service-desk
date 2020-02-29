import React, { PureComponent } from 'react';
import { RequestItem } from './RequestItem';
import * as yup from 'yup'
import { Formik } from 'formik';

interface Props {
    request: RequestItem,
    onClose: () => void
}

const ticketSchema = yup.object({
    summary: yup.string().required(),
    description: yup.string().required(),
    category: yup.string().required(),
    subcategory: yup.string().required(),
    source: yup.string().required(),
    creator: yup.string().required()
});

// type ticketType = yup.InferType<typeof ticketSchema>;

export default class EditRequestForm extends PureComponent<Props> {
    render() {
        const request = this.props.request;
        return (
            <div>
                {request.id}
                <Formik
                    initialValues={{
                        summary: request.summary,
                        description: '',
                        category: '',
                        subcategory: '',
                        source: '',
                        creator: ''
                    }}
                    onSubmit={async values => {
                        await new Promise(resolve => setTimeout(resolve, 500));
                        alert(JSON.stringify(values, null, 2));
                    }}
                    validationSchema={ticketSchema}
                >
                    {props => {
                        const {
                            values,
                            touched,
                            errors,
                            dirty,
                            isSubmitting,
                            handleChange,
                            handleBlur,
                            handleSubmit,
                            handleReset
                        } = props;
                        return (
                            <form onSubmit={handleSubmit}>
                                <div>
                                    <label htmlFor="summary">
                                        Summary
                                    </label>
                                    <input
                                        id="summary"
                                        placeholder="Short summary of request"
                                        type="text"
                                        value={values.summary}
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        className={
                                            errors.summary && touched.summary
                                                ? "text-input error"
                                                : "text-input"
                                        }
                                    />
                                    {errors.summary && touched.summary && (
                                        <div className="input-feedback">{errors.summary}</div>
                                    )}
                                </div>

                                <button
                                    type="button"
                                    className="outline"
                                    onClick={handleReset}
                                    disabled={!dirty || isSubmitting}>Reset</button>
                                <button type="submit" disabled={isSubmitting}>Submit</button>
                            </form>
                        );
                    }}
                </Formik>
            </div>)
    }
}