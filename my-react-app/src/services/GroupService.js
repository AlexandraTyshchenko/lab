import axios from 'axios';


const GroupService = {

    async getAll() {
        try {
            const apiUrl =` https://localhost:7292`;
            const response = await axios.get(`${apiUrl}/api/Group`);
            return response.data;
        } catch (error) {
            throw error;
        }
    }
};

export default GroupService;
