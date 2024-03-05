import React from 'react';

function NewsItem({ newsItem }) {
    // Chuyển đổi ngày từ chuỗi sang đối tượng Date
    const createdAtDate = new Date(newsItem.createdAt);
    // Định dạng ngày theo "dd-MM-yyyy"
    const formattedDate = `${createdAtDate.getDate()}/${createdAtDate.getMonth() + 1}/${createdAtDate.getFullYear()}`;

    return (
        <div className="newsItem">
            <img src={`https://localhost:7252/${newsItem.imageUrl}`} alt={newsItem.title} title={newsItem.title} />
            <br />
            <p className="type">{newsItem.type}</p>
            <span className="daucham"></span>
            <p>{formattedDate}</p>
            <h2>{newsItem.title}</h2>
            <p>{newsItem.shortContent}</p>
        </div>
    );
}

export default NewsItem;