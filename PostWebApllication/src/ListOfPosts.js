import React, { Component } from 'react';
import { variables } from './Variables';
import { Comments } from './Comments';
import { format } from 'date-fns'
export class ListOfPosts extends Component {
    constructor(props) {
        super(props);
        this.state = {
            addposts: [],
            modalTitle: "",
            PostID: '',
            PostTittle: "",
            DescriptionOfPost: "",
            CreatedDate: "",
            UpdatedDate: "",
            LikesCount: "",
            HeartCount: "",
            modalPostId: null
        }
    }
    refreshList() {
        debugger;
        fetch(variables.API_URL + 'AddPost/GetPosts')
            .then(response => response.json())
            .then(data => {
                this.setState({ addposts: data });
            });
    }
    debugger;
    componentDidMount() {
        this.refreshList();
    }
    changePostTittle = (e) => {
        this.setState({ PostTittle: e.target.value });
    }
    changeDescriptionOfPost = (e) => {
        this.setState({ DescriptionOfPost: e.target.value });
    }

    addClick() {
        debugger;
        this.setState({
            modalTitle: "Add Post",
            PostId: '',
            PostTittle: "",
            DescriptionOfPost: "",
            CreatedDate: "",
            UpdatedDate: "",
            LikesCount: "",
            HeartCount: ""
        });
    }
    editClick(a1) {
        debugger;
        this.setState({
            modalTitle: "Edit Post",
            PostID: a1.PostID,
            PostTittle: a1.PostTittle,
            DescriptionOfPost: a1.DescriptionOfPost,
        });
    }
    debugger;
    updateClick() {
        debugger;
        fetch(variables.API_URL + 'AddPost/UpdatePost', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                PostID: this.state.PostID,
                PostTittle: this.state.PostTittle,
                DescriptionOfPost: this.state.DescriptionOfPost,
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
    debugger;
    createClick() {
        debugger;
        fetch(variables.API_URL + 'AddPost/CreatePost', {

            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                PostTittle: this.state.PostTittle,
                DescriptionOfPost: this.state.DescriptionOfPost,
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
    LikeClick(row) {
        debugger;
        fetch(variables.API_URL + 'AddPost/POSTLIKE', {

            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                PostID: row.PostID,
                LikesCount: row.LikesCount + 1
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
    HeartClick(row) {
        debugger;
        fetch(variables.API_URL + 'AddPost/POSTHEART', {

            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                PostID: row.PostID,
                HeartCount: row.HeartCount + 1
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
            addposts,
            modalTitle,
            PostID,
            PostTittle,
            DescriptionOfPost
        } = this.state;
        return (
            <div>
                <div className="text-center" ><h1 className="text-white bg-primary">Social Post</h1></div>
                <button type="button"
                    className="btn btn-secondary btn-lg btn-block"
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>Add Post</button>
                <div>
                    {addposts.map(a1 =>
                        <>
                            <div key={a1.PostID} >
                                <div className="card text-center  border-info mb-3 ">
                                    <div className="card-header"><b> PostID:   </b>{a1.PostID} </div>
                                    <div className="card-body text-danger">
                                        <h5 className="card-title">{a1.PostTittle}</h5>
                                        <p className="card-text">{a1.DescriptionOfPost}</p>
                                        <button type="button" className="btn btn-primary  col-xs-2 margin-left"
                                            onClick={() => this.LikeClick(a1)} >
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-hand-thumbs-up-fill" viewBox="0 0 16 16">
                                                <path d="M6.956 1.745C7.021.81 7.908.087 8.864.325l.261.066c.463.116.874.456 1.012.965.22.816.533 2.511.062 4.51a9.84 9.84 0 0 1 .443-.051c.713-.065 1.669-.072 2.516.21.518.173.994.681 1.2 1.273.184.532.16 1.162-.234 1.733.058.119.103.242.138.363.077.27.113.567.113.856 0 .289-.036.586-.113.856-.039.135-.09.273-.16.404.169.387.107.819-.003 1.148a3.163 3.163 0 0 1-.488.901c.054.152.076.312.076.465 0 .305-.089.625-.253.912C13.1 15.522 12.437 16 11.5 16H8c-.605 0-1.07-.081-1.466-.218a4.82 4.82 0 0 1-.97-.484l-.048-.03c-.504-.307-.999-.609-2.068-.722C2.682 14.464 2 13.846 2 13V9c0-.85.685-1.432 1.357-1.615.849-.232 1.574-.787 2.132-1.41.56-.627.914-1.28 1.039-1.639.199-.575.356-1.539.428-2.59z" />
                                            </svg>
                                            <span className="badge badge-light">{a1.LikesCount}</span>
                                        </button>
                                        <button type="button" className="btn btn-primary  col-xs-2 margin-left" onClick={() => this.HeartClick(a1)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-heart-fill" viewBox="0 0 16 16">
                                                <path fillRule="evenodd" d="M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z" />
                                            </svg>
                                            <span className="badge badge-light">{a1.HeartCount}</span>
                                        </button>
                                        <button type="button" className="btn btn-primary  col-xs-2 margin-left"
                                            data-bs-toggle="modal"
                                            data-bs-target="#exampleModal"
                                            onClick={() => this.editClick(a1)} >
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" /></svg>
                                        </button>

                                        <button type="button" className="btn btn-primary col-xs-2 margin-left" onClick={() => this.setState({ modalPostId: a1.PostID })} >
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-chat" viewBox="0 0 16 16">
                                                <path d="M2.678 11.894a1 1 0 0 1 .287.801 10.97 10.97 0 0 1-.398 2c1.395-.323 2.247-.697 2.634-.893a1 1 0 0 1 .71-.074A8.06 8.06 0 0 0 8 14c3.996 0 7-2.807 7-6 0-3.192-3.004-6-7-6S1 4.808 1 8c0 1.468.617 2.83 1.678 3.894zm-.493 3.905a21.682 21.682 0 0 1-.713.129c-.2.032-.352-.176-.273-.362a9.68 9.68 0 0 0 .244-.637l.003-.01c.248-.72.45-1.548.524-2.319C.743 11.37 0 9.76 0 8c0-3.866 3.582-7 8-7s8 3.134 8 7-3.582 7-8 7a9.06 9.06 0 0 1-2.347-.306c-.52.263-1.639.742-3.468 1.105z" />
                                            </svg></button>
                                        {this.state.modalPostId && <Comments PostID={this.state.modalPostId} onClose={() => this.setState({ modalPostId: null })} />}
                                    </div>
                                    <div className="card-footer text-muted">
                                        <div className="float-none">CreatedDate:{format(new Date(a1.CreatedDate), 'dd-MM-yyyy')}</div>
                                        <div className="float-sm-right">UpdatedDate:{format(new Date(a1.UpdatedDate),'dd-MM-yyyy')}</div>
                                    </div>
                                </div>
                            </div>
                        </>
                    )},
                    <div className="modal fade" id="exampleModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div className="modal-dialog modal-lg modal-dialog-centered">
                            <div className="modal-content">
                                <div className="modal-header text-white bg-primary">
                                    <h5 className="col-11 modal-title text-center">{modalTitle}</h5>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body ">
                                    <div className="input-group mb-3">
                                        <div class="d-flex flex-column bd-highlight mb-3">
                                            <h4>PostTittle:</h4>
                                            <input type="text" className="form-control input-lg" value={PostTittle} onChange={this.changePostTittle} />
                                        </div>
                                        <div className="input-group mb-3">
                                            <h5 className="input-group mb-3">DescriptionOfPost:</h5>
                                            <textarea className="form-control" rows="5" value={DescriptionOfPost} onChange={this.changeDescriptionOfPost}></textarea>
                                        </div>
                                    </div>
                                </div>
                                {PostID == 0 ?
                                    <button type="button" className="btn btn-primary" onClick={() => this.createClick()}>Create</button> : null}
                                <button type="button" className="btn btn-primary" onClick={() => this.updateClick()}>update</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}
