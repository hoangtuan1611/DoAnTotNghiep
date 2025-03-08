import { Layout, DatePicker, Button } from "antd";
import React, { useEffect, useState } from "react";
import axios from "axios";
import SideBar from "../components/SideBar";
import dayjs from "dayjs";
import LineChartCustom from "../components/LineChartCustom";
import BarChartCustom from "../components/BarChartCustom";

const apiCourse = import.meta.env.VITE_API_COURSE;
const apiClass = import.meta.env.VITE_API_CLASS;

// const className = ["CTK45A", "CTK45B", "CTK46A", "CTK46B"];
// const courseName = [
//   "Lập trình Python",
//   "Hướng đối tượng",
//   "Ứng dụng desktop",
//   "Dữ liệu và thuật giải",
// ];
const dataChart = [
  { time: "Buổi 2 (02/02/2025)", count: "30" },
  { time: "Buổi 3 (03/02/2025)", count: "80" },
  { time: "Buổi 4 (04/02/2025)", count: "55" },
  { time: "Buổi 5 (02/02/2025)", count: "30" },
  { time: "Buổi 6 (02/02/2025)", count: "30" },
  { time: "Buổi 7 (02/02/2025)", count: "30" },
];

function Statistics() {
  const [courseName, setCourseName] = useState([]);
  const [className, setClassName] = useState([]);

  const getCourse = async () => {
    const result = await axios.get(apiCourse);
    const course = result.data.map((item) => item.courseName);
    setCourseName(course);
  };

  const getClass = async () => {
    const result = await axios.get(apiClass);
    const data = result.data.map((item) => item.classId);
    setClassName(data);
  };

  useEffect(() => {
    getCourse();
    getClass();
  }, []);

  return (
    <Layout style={{ minHeight: "100vh", minWidth: "98vw" }}>
      <SideBar />
      <Layout>
        <div className="h-auto bg-gradient-to-br from-blue-50 to-indigo-50 p-6 flex flex-col gap-6">
          <div className="datetime flex justify-end">
            <DatePicker
              style={{ margin: "1rem" }}
              format={"DD-MM-YYYY HH:mm"}
              inputReadOnly={true}
              allowClear={false}
              defaultValue={dayjs()}
            />
            <DatePicker
              style={{ margin: "1rem" }}
              format={"DD-MM-YYYY HH:mm"}
              inputReadOnly={true}
              allowClear={false}
              defaultValue={dayjs()}
            />
          </div>
          <div className="bg-white backdrop-blur-sm hover:shadow-lg transition-all duration-300 p-10 rounded-2xl">
            <div className="mb-2 class">
              <h1 className="text-2xl font-bold bg-gradient-to-r from-indigo-600 via-purple-600 to-blue-600 bg-clip-text text-transparent">
                Báo cáo theo môn học
              </h1>
              <p className="text-base">Chọn lớp để xem thống kê</p>
            </div>
            <div className="grid grid-cols-2 gap-4 mb-5">
              {className.map((item, index) => (
                <Button
                  style={{ backgroundColor: "#6366F1" }}
                  key={index}
                  block
                  type="primary"
                  htmlType="submit"
                >
                  {item}
                </Button>
              ))}
            </div>
            <div className="course">
              <p className="text-base mb-2">Chọn môn học</p>
              <div className="grid grid-cols-2 gap-4">
                {courseName.map((item, index) => (
                  <Button
                    style={{ backgroundColor: "#3B82F6" }}
                    key={index}
                    block
                    type="primary"
                    htmlType="submit"
                  >
                    {item}
                  </Button>
                ))}
              </div>
            </div>
            <div className="chart h-72 mt-10">
              <LineChartCustom data={dataChart} />
            </div>
          </div>
          <div className="lecturer bg-white backdrop-blur-sm hover:shadow-lg transition-all duration-300 p-10 rounded-2xl">
            <h1 className="text-2xl font-bold bg-gradient-to-r from-indigo-600 via-purple-600 to-blue-600 bg-clip-text text-transparent mb-2">
              Báo cáo theo giáo viên
            </h1>
            <div className="h-72">
              <BarChartCustom data={dataChart} />
            </div>
          </div>
        </div>
      </Layout>
    </Layout>
  );
}

export default Statistics;
