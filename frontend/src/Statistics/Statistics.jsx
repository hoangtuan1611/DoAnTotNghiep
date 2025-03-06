import { Layout, DatePicker, Button } from "antd";
import React from "react";
import SideBar from "../components/SideBar";
import dayjs from "dayjs";
import Chart from "../components/Chart";

const className = ["CTK45A", "CTK45B", "CTK46A", "CTK46B"];
const courseName = [
  "Lập trình Python",
  "Hướng đối tượng",
  "Ứng dụng desktop",
  "Dữ liệu và thuật giải",
];
const dataChart = [
  { time: "Buổi 2 (02/02/2025)", count: "30" },
  { time: "Buổi 3 (03/02/2025)", count: "80" },
  { time: "Buổi 4 (04/02/2025)", count: "55" },
  { time: "Buổi 5 (02/02/2025)", count: "30" },
  { time: "Buổi 6 (02/02/2025)", count: "30" },
  { time: "Buổi 7 (02/02/2025)", count: "30" },
];

function Statistics() {
  return (
    <Layout style={{ minHeight: "100vh", minWidth: "100vw" }}>
      <SideBar />
      <Layout style={{ marginLeft: "5rem" }}>
        <div className="h-screen bg-gradient-to-br from-blue-50 to-indigo-50 p-6">
          <div className="datetime flex justify-end">
            <DatePicker
              style={{ margin: "1rem" }}
              format={"DD-MM-YYYY HH:mm"}
              allowClear={false}
              defaultValue={dayjs("06-03-2025")}
            />
            <DatePicker
              style={{ margin: "1rem" }}
              format={"DD-MM-YYYY HH:mm"}
              allowClear={false}
              defaultValue={dayjs("06-03-2025")}
            />
          </div>
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
            <Chart data={dataChart} />
          </div>
        </div>
      </Layout>
    </Layout>
  );
}

export default Statistics;
