import React, { Component } from 'react';
import { variables } from './Variables';
import { format } from 'date-fns'
export class Comments extends Component {
    constructor(props) {
        super(props);
        this.state = {
            addcomments: [],
            modaltitle: "",
            commentId: '',
            commentText: "",
            postId: props.postId,
            commentsCreatedDate: "",
            commentsUpdatedDate: "",
            onClose: props.onClose
        }
    }
    refreshList() {
        fetch(variables.API_URL + 'Comments/GetComments/' + this.props.postId)
            .then(response => response.json())
            .then(data => {
                this.setState({ addcomments: data });
            });
    }
    componentDidMount() {
        this.refreshList();
    }
    changeCommentText = (e) => {
        this.setState({ commentText: e.target.value });
    }
    addComments(postId) {
        this.setState({
            modaltitle: "Add Comments",
            modaltitle: "",
            commentId: '',
            commentText: "",
            postId: postId,
            commentsCreatedDate: "",
            commentsUpdatedDate: ""
        });
    }
    editComments(c1) {
        this.setState({
            modalTitle: "Edit Comments",
            commentId: c1.commentId,
            commentText: c1.commentText,
            commentsUpdatedDate: c1.commentsUpdatedDate,
            postId: c1.postId
        });
    }
    updateComments(id) {
        fetch(variables.API_URL + `Comments/UpdateComment/${id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                commentId: id,
                commentText: this.state.commentText,
                commentsUpdatedDate: this.state.commentsUpdatedDate,
                postId: this.state.postId
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }
    createComments() {
        fetch(variables.API_URL + 'Comments/CreateComment', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                commentText: this.state.commentText,
                postId: this.state.postId
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            })
    }
    render() {
        const {
            addcomments,
            commentId,
            commentText
        } = this.state;
        return (
            <div>
                <div className="modal d-block" >
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header text-white bg-primary">
                                <h5 className="col-11 modal-title text-center" id="examplemodalLabel">Comments</h5>
                                <button type="button" className="btn-close btn-close-white" data-dismiss="modal d-block" aria-label="Close" onClick={this.state.onClose}></button>
                            </div>
                            <div className="modal-body ">
                                <form >
                                    <div className="input-group mb-3">
                                        <h5 className="input-group mb-3">CommentText:</h5>
                                        <textarea className="form-control" rows="2" value={commentText} onChange={this.changeCommentText}></textarea>
                                    </div>
                                </form>
                                <div>
                                    {commentId == 0 ?
                                        <button type="button" className="btn btn-primary col-xs-2 margin-left " onClick={() => this.createComments()} >Create</button> : null}
                                    <button type="button" className="btn btn-primary col-xs-2 margin-left " onClick={() => this.updateComments(commentId)}>update</button>
                                </div>
                                {addcomments.map(c1 =>
                                    <>
                                        <div key={c1.commentId}>
                                            <div className="card text-center  border-info mb-3 ">
                                                <div className="card-header text-primary mb-3"><b> CommentId: </b>{c1.commentId} </div>
                                                <div className="card-body  text-dark">
                                                    <h5 className="card-title">PostId:{c1.postId}</h5>
                                                    <p className="card-text">{c1.commentText}</p>
                                                    <button type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exmodal" onClick={() => this.editComments(c1)}>
                                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                            <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" /></svg>
                                                    </button>
                                                </div>
                                                <div className="card-footer text-muted">
                                                    <div className="float-none">CreatedDate:{format(new Date(c1.commentsCreatedDate), 'dd-MM-yyyy')}</div>
                                                    <div className="float-sm-right">UpdatedDate:{format(new Date(c1.commentsUpdatedDate), 'dd-MM-yyyy')}</div>
                                                </div>
                                            </div>
                                        </div>
                                    </>
                                )},
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
