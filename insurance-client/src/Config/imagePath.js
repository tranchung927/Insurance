const baseURL = process.env.REACT_APP_API_BASE_URL;

const imagePaths = {
  getImageURL: (imageName) => `${baseURL}${imageName}`,
};

export default imagePaths;