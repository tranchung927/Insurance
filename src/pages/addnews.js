import React, { useState } from 'react';
import '../styles/addnews.css';

function AddPostForm() {
    const [showPopup, setShowPopup] = useState(true);

    const handleLogin = async (event) => {
        event.preventDefault();

        const username = event.target.elements.username.value;
        const password = event.target.elements.password.value;

        try {
            const response = await fetch(`https://localhost:7252/api/Login/getaccount/${username}/${password}`);
            const data = await response.json();

            if (data.role === 'admin') {
                setShowPopup(false);
            } else {
                alert('Bạn không có quyền truy cập.');
            }
        } catch (error) {
            console.error('Có lỗi xảy ra:', error);
        }
    };

    const handleAddPost = async (event) => {
        event.preventDefault();

        const title = event.target.elements.title.value;
        const content = event.target.elements.content.value;
        const shortContent = event.target.elements.shortContent.value;
        const personId = event.target.elements.personId.value;
        const type = event.target.elements.type.value;
        const img = event.target.elements.img.files[0];

        const formData = new FormData();
        formData.append('title', title);
        formData.append('content', content);
        formData.append('shortContent', shortContent);
        formData.append('personId', personId);
        formData.append('type', type);
        formData.append('img', img);

        try {
            const response = await fetch('https://localhost:7252/insert', {
                method: 'POST',
                body: formData
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const responseData = await response.json();
            alert('Post added successfully:', responseData);
        } catch (error) {
            console.error('There was a problem adding the post:', error);
        }
    };

    return (
        <div>
            {showPopup && (
                <div className="popup-overlay" id="popup-overlay">
                    <div className="popup" id="popup">
                        <h2>Login</h2>
                        <form id="loginForm" onSubmit={handleLogin}>
                            <label htmlFor="username">Username:</label>
                            <input type="text" id="username" name="username" placeholder="Enter your username" required />
                            <label htmlFor="password">Password:</label>
                            <input type="password" id="password" name="password" placeholder="Enter your password" required />
                            <button type="submit" id="loginButton">Login</button>
                        </form>
                    </div>
                </div>
            )}

            <div className="container">
                <form id="addPostForm" encType="multipart/form-data" onSubmit={handleAddPost}>
                    <h1>Add News</h1>
                    <label htmlFor="title">Title:</label>
                    <input type="text" id="title" name="title" required />

                    <label htmlFor="content">Content:</label>
                    <textarea id="content" name="content" rows="4" required></textarea>

                    <label htmlFor="shortContent">Short Content:</label>
                    <input type="text" id="shortContent" name="shortContent" required />

                    <label htmlFor="personId">PersonId:</label>
                    <input type="text" id="personId" name="personId" required />

                    <label htmlFor="type">Type:</label>
                    <select id="type" name="type" required>
                        <option value="Business">Business</option>
                        <option value="Technology">Technology</option>
                        <option value="Customer">Customer</option>
                    </select>

                    <label htmlFor="img">Image:</label>
                    <input type="file" id="img" name="img" accept="image/*" required />

                    <input type="submit" value="Add Post" id="addpost" />
                </form>
            </div>
        </div>
    );
}

export default AddPostForm;