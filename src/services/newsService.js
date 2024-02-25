import axios from 'axios';

const API_URL = 'https://localhost:7252/api/News/all';

const getNews = async () => {
    try {
        const response = await axios.get(API_URL);
        return response.data;
    } catch (error) {
        console.error('Error loading news:', error);
        throw error;
    }
};

export { getNews };
