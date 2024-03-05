import React, { useState, useEffect } from 'react';
import Header from '../Component/header';
import NewsItem from '../Component/NewsItem';
import '../styles/news.css';
import axios from 'axios';



function ListNews() {
    const [news, setNews] = useState([]);
    const API_URL = 'https://localhost:7188/Posts?orderBy=Desc&sortBy=Publication&page=1&pageSize=100';

    const getNews = async () => {
        try {
            const response = await axios.get(API_URL);
            return response.data;
        } catch (error) {
            console.error('Error loading news:', error);
            throw error;
        }
    };

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

export default ListNews;
