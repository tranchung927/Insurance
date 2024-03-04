import React, { useState, useEffect } from 'react';
import '../styles/addnews.css';

function AddPostForm() {
    const [posts, setPosts] = useState([]);
    const [formData, setFormData] = useState({
        title: '',
        content: '',
        shortContent: '',
        personId: '',
        type: '',
        img: null
    });
    const [isEditing, setIsEditing] = useState(false); // State để kiểm tra xem người dùng đang chỉnh sửa hay không
    const [editId, setEditId] = useState(null); // State để lưu ID của bài viết đang được chỉnh sửa

    useEffect(() => {
        fetchPosts();
    }, []);

    const fetchPosts = () => {
        fetch('https://localhost:7252/api/News/all')
            .then(response => response.json())
            .then(data => setPosts(data))
            .catch(error => console.error('Error fetching posts:', error));
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        const postData = new FormData();
        postData.append('title', formData.title);
        postData.append('content', formData.content);
        postData.append('shortContent', formData.shortContent);
        postData.append('personId', formData.personId);
        postData.append('type', formData.type);
        postData.append('img', formData.img);

        if (isEditing && editId) {
            updatePost(editId, postData); // Nếu đang chỉnh sửa, gọi hàm updatePost
        } else {
            addPost(postData); // Nếu không, gọi hàm addPost
        }
    };

    const addPost = (postData) => {
        fetch('https://localhost:7252/insert', {
            method: 'POST',
            body: postData
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                alert('Post added successfully');
                fetchPosts();
                clearFormData();
            })
            .catch(error => {
                console.error('There was a problem adding the post:', error);
            });
    };

    const editPost = (newsId) => {
        setIsEditing(true);
        setEditId(newsId);
        fetch(`https://localhost:7252/getNews/${newsId}`)
            .then(response => response.json())
            .then(data => {
                setFormData({
                    title: data.title,
                    content: data.content,
                    shortContent: data.shortContent,
                    personId: data.personId,
                    type: data.type,
                    img: null
                });
            })
            .catch(error => {
                console.error('Error fetching post details:', error);
            });
    };

    const updatePost = (newsId, postData) => {
        fetch(`https://localhost:7252/update/${newsId}`, {
            method: 'PUT',
            body: postData
        })
            .then(response => response.json())
            .then(data => {
                alert('Bài viết đã được cập nhật thành công:', data);
                fetchPosts();
                clearFormData();
                setIsEditing(false);
                setEditId(null);
            })
            .catch(error => {
                console.error('Lỗi khi cập nhật bài viết:', error);
            });
    };

    const deletePost = (newsId) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa bài viết này không?")) {
            fetch(`https://localhost:7252/delete/${newsId}`, {
                method: 'DELETE'
            })
                .then(response => {
                    if (response.ok) {
                        alert(`Bài viết có ID ${newsId} đã được xóa thành công.`);
                        fetchPosts();
                    } else {
                        alert(`Lỗi khi xóa bài viết có ID ${newsId}.`);
                    }
                })
                .catch(error => {
                    console.error('Lỗi khi gửi yêu cầu xóa bài viết:', error);
                });
        } else {
            alert('Người dùng đã hủy xóa bài viết.');
        }
    };

    const clearFormData = () => {
        setFormData({
            title: '',
            content: '',
            shortContent: '',
            personId: '',
            type: '',
            img: null
        });
    };

    return (
        <div>
            <div className="container">
                <form onSubmit={handleSubmit} encType="multipart/form-data">
                    <h1>{isEditing ? 'Update News' : 'Add News'}</h1>
                    <label htmlFor="title">Title:</label>
                    <input type="text" id="title" name="title" value={formData.title} onChange={(e) => setFormData({ ...formData, title: e.target.value })} required />

                    {/* Các trường input khác */}
                    <label htmlFor="content">Content:</label>
                    <textarea id="content" name="content" rows="4" value={formData.content} onChange={(e) => setFormData({ ...formData, content: e.target.value })} required></textarea>

                    <label htmlFor="shortContent">Short Content:</label>
                    <input type="text" id="shortContent" name="shortContent" value={formData.shortContent} onChange={(e) => setFormData({ ...formData, shortContent: e.target.value })} required />

                    <label htmlFor="personId">PersonId:</label>
                    <input type="text" id="personId" name="personId" value={formData.personId} onChange={(e) => setFormData({ ...formData, personId: e.target.value })} required />

                    <label htmlFor="type">Type:</label>
                    <select id="type" name="type" value={formData.type} onChange={(e) => setFormData({ ...formData, type: e.target.value })} required>
                        <option value="Business">Business</option>
                        <option value="Techlonogy">Techlonogy</option>
                        <option value="Customer">Customer</option>
                    </select>

                    <label htmlFor="img">Image:</label>
                    <input type="file" id="img" name="img" accept="image/*" onChange={(e) => setFormData({ ...formData, img: e.target.files[0] })} required />

                    <input type="submit" value={isEditing ? 'Update Post' : 'Add Post'} />
                </form>
            </div>

            <div className="table-container">
                <table id="postTable">
                    <thead>
                        <tr>
                            <th>NewsId</th>
                            <th>Title</th>
                            <th>Content</th>
                            <th>Type</th>
                            <th>Short Content</th>
                            <th>Image</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {posts.map(post => (
                            <tr key={post.newsId}>
                                <td>{post.newsId}</td>
                                <td>{post.title}</td>
                                <td>{post.content}</td>
                                <td>{post.type}</td>
                                <td>{post.shortContent}</td>
                                <td><img src={`https://localhost:7252/${post.imageUrl}`} style={{ maxWidth: '100px' }} alt="Post" /></td>
                                <td>
                                    <button className="bt-edit" onClick={() => editPost(post.newsId)}>Edit</button>
                                    <button className="bt-delete" onClick={() => deletePost(post.newsId)}>Delete</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default AddPostForm;
