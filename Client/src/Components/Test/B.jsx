import React, { useEffect } from 'react';
import A from './A';

const xxx = ({ x, handleChangex }) => {
    useEffect(() => {
        // Thay đổi x thành y
        const y = 10;
        handleChangex(y);
    }, []);

    return (
        <div>
            <h1>Component B</h1>
            <p>Giá trị x: {x}</p>
        </div>
    );
};

export default xxx;

