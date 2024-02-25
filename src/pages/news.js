import React, { useState, useEffect } from 'react';
import Header from '../components/header';
import NewsItem from '../components/newsItem';
import { getNews } from '../services/newsService';
import '../styles/news.css';

function News() {
    const [news, setNews] = useState([]);

    useEffect(() => {
        const fetchNews = async () => {
            try {
                const newsData = await getNews();
                setNews(newsData.reverse());
            } catch (error) {
                console.error('Error loading news:', error);
            }
        };

        fetchNews();
    }, []);

    return (
        <div>
            <Header />
            <div id="newsFeed">
                {news.map((newsItem) => (
                    <NewsItem key={newsItem.id} newsItem={newsItem} />
                ))}
            </div>
        </div>
    );
}

export default News;
