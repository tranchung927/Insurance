import { createContext,useState,useEffect,useContext} from "react";
import BannerNew from "../Img/banner-news.webp";

import axios from "axios";
export const DataContext = createContext();

export const DataProvider = ({children}) => {
  const [insuranceTypes,setInsuranceType] = useState([]);
  const [productNews,setProductNews] = useState([]);
  const [businesslocation,getBussinessLocation] = useState([]);
  const [provinces,setProvinces] = useState([]);
  const [valueTab, setValueTab] = useState("0");
  const [getAllProvince,setGetAllProvince] = useState([]);


  console.log(valueTab)
  const handleChangeTab = (event, newValue) => {
    setValueTab(newValue);
  };

  // get all product
  useEffect(() => {
    axios
      .get("https://localhost:7064/InsuranceType/getAll")
      .then((response) => {
        setInsuranceType(response.data);
      })
      .catch((error) => {
        console.error("Lỗi khi gọi API:", error);
      });
  }, []);
  // gett all product news
  useEffect(() => {
    axios
      .get("https://localhost:7064/NewsInsuranceType/GetAllNewsInsuranceType")
      .then((response) => {
        setProductNews(response.data);
      })
      .catch((error) => {
        console.error("Lỗi khi gọi API:", error);
      });
  }, []);
  // gett all business location
  useEffect(() => {
    axios
      .get("https://localhost:7064/BusinessLocation/GetAll")
      .then((response) => {
        getBussinessLocation(response.data);
      })
      .catch((error) => {
        console.error("Lỗi khi gọi API:", error);
      });
  }, []);
  
  // gett all province
  useEffect(() => {
    axios
      .get("https://localhost:7064/Province/GetProvince")
      .then((response) => {
        setProvinces(response.data);
      })
      .catch((error) => {
        console.error("Lỗi khi gọi API:", error);
      });
  }, []);
   // get all product
   useEffect(() => {
    axios
      .get("https://vapi.vnappmob.com/api/province/")
      .then((response) => {
       setGetAllProvince(response.data);
      })
      .catch((error) => {
        console.error("Lỗi khi gọi API:", error);
      });
  }, []);
 
  

  const peopleArray = [
    {
      name: "John Doe",
      birthYear: 1990,
      gender: "Male",
      occupation: "Engineer",
      address: "123 Main St, Cityville",
      phoneNumber: "123-456-7890",
      email: "john.doe@example.com",
      maritalStatus: "Single",
    },
    {
      name: "Jane Smith",
      birthYear: 1985,
      gender: "Female",
      occupation: "Doctor",
      address: "456 Oak St, Townsville",
      phoneNumber: "987-654-3210",
      email: "jane.smith@example.com",
      maritalStatus: "Married",
    },
  ];
  // const insuranceTypes = [
  //   {
  //     type: "Live Insurance",
  //     description:
  //       "Protects you and your vehicle in case of accidents or losses.",
  //     coverage: "Liability insurance, loss and damage insurance.",
  //     image_url: InsuranceHouse,
  //   },
  //   {
  //     type: "Home Insurance",
  //     description: "Protects your home from risks and damages.",
  //     coverage: "Fire insurance, loss and other damages coverage.",
  //     image_url: InsuranceHouse,
  //   },
  //   {
  //     type: "Health Insurance",
  //     description: "Safeguards your health and covers medical expenses.",
  //     coverage:
  //       "Healthcare coverage, surgery insurance, and other medical services.",
  //     image_url: InsuranceHouse,
  //   },
  //   {
  //     type: "Social Insurance",
  //     description: "Protects workers and families in challenging situations.",
  //     coverage:
  //       "Unemployment insurance, maternity insurance, and other social benefits.",
  //     image_url: InsuranceHouse,
  //   },
  // ];

  const navItems = [
    { label: "Introduce" },
    {
      label: "Product",
    },
    { label: "Service", children: ["Suport ", "Other"] },
    { label: "News" },
    { label: "Contact" },
  ];
  const news = [
    {
      urlImg: BannerNew,
      date: "2024-01-17",
      title: "Breaking News 1",
      description: "This is the first breaking news description.",
      newsType: "Social activities",
    },
    {
      urlImg: BannerNew,
      date: "2024-01-18",
      title: "Breaking News 2",
      description: "This is the second breaking news description.",
      newsType: "Social activities",
    },
    {
      urlImg: BannerNew,
      date: "2024-01-19",
      title: "Breaking News 3",
      description: "This is the third breaking news description.",
      newsType: "News for customers",
    },
    {
      urlImg: BannerNew,
      date: "2024-01-20",
      title: "Breaking News 4",
      description: "This is the fourth breaking news description.",
      newsType: "Social activities",
    },
    {
      urlImg: BannerNew,
      date: "2024-01-21",
      title: "Breaking News 5",
      description: "This is the fifth breaking news description.",
      newsType: "Business activities",
    },
  ];
  
console.log(getAllProvince)
  return (
    <DataContext.Provider
    value={{ 
      peopleArray,insuranceTypes, navItems, news,productNews,businesslocation,provinces,getAllProvince
      ,valueTab,handleChangeTab
    }}
  >
    {children}
  </DataContext.Provider>
  );
};