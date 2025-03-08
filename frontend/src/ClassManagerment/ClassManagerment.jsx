import { Layout, Tabs, List, DatePicker } from "antd";
import dayjs from "dayjs";
import React, { useState } from "react";
import SideBar from "../components/SideBar";
import LineChartCustom from "../components/LineChartCustom";
import AddClass from "../AddNew/AddClass";
import AddCourse from "../AddNew/AddCourse";

const classList = [
  {
    class: "CTK45A",
    lecturer: "Nguyễn Văn A",
    time: "7:30 - 9:30",
    room: "A24.1",
    maxStudents: 30,
  },
  {
    class: "CTK45B",
    lecturer: "Nguyễn Văn A",
    time: "7:30 - 9:30",
    room: "A24.1",
    maxStudents: 25,
  },
];

const historyList = [
  {
    class: "CTK45A",
    time: "7:30 - 9:30",
    data: [
      { time: "07:30", count: 10 },
      { time: "08:00", count: 18 },
      { time: "08:30", count: 22 },
      { time: "09:00", count: 25 },
      { time: "09:30", count: 30 },
    ],
  },
  {
    class: "CTK45B",
    time: "7:30 - 9:30",
    data: [
      { time: "07:30", count: 10 },
      { time: "08:00", count: 18 },
      { time: "08:30", count: 22 },
      { time: "09:00", count: 25 },
      { time: "09:30", count: 30 },
    ],
  },
];

export const ClassContent = () => {
  return (
    <div className="bg-blue-100 pt-6 pb-6 rounded-lg">
      <h1 className="mb-3 ml-6">Danh sách lớp học</h1>
      <div className="pl-6 pr-6 pt-1 pb-1 bg-white">
        <List
          itemLayout="horizontal"
          dataSource={classList}
          renderItem={(item, index) => (
            <List.Item className="bg-blue-50 flex flex-col !items-start rounded-lg mt-3 mb-3">
              <List.Item.Meta
                className="pl-6"
                title={<a href="">{item.class}</a>}
              />
              <div className="flex flex-col pl-6">
                <span>
                  {item.lecturer} - {item.time} - {item.room}
                </span>
                <span>Sỉ số: {item.maxStudents}</span>
              </div>
            </List.Item>
          )}
        />
      </div>
    </div>
  );
};

export const HistoryContent = () => {
  return (
    <div className="flex gap-6">
      <div className="flex-1 rounded-lg bg-white">
        <div className="flex justify-between items-start h-fit">
          <p className="text-indigo-900 p-3 text-base">Lịch sử lớp học</p>
          <DatePicker
            style={{ margin: "1rem" }}
            format={"DD-MM-YYYY"}
            inputReadOnly={true}
            allowClear={false}
            defaultValue={dayjs()}
          />
        </div>
        <div className="ml-5 mr-5">
          <List
            itemLayout="horizontal"
            dataSource={classList}
            renderItem={(item, index) => (
              <List.Item className="bg-blue-50 flex flex-col !items-start rounded-lg mt-3 mb-3">
                <List.Item.Meta
                  className="pl-6"
                  title={<a href="">{item.class}</a>}
                />
                <div className="flex flex-col pl-6">
                  <span>
                    {item.lecturer} - {item.time} - {item.room}
                  </span>
                  <span>Sỉ số: {item.maxStudents}</span>
                </div>
              </List.Item>
            )}
          />
        </div>
      </div>
      <div className="chart flex-2 rounded-lg bg-white">
        <p className="text-indigo-900 p-3 text-base">
          Thống kê điểm danh lớp {historyList[0].class}
        </p>
        <div className="h-72">
          <LineChartCustom data={historyList[0].data} />
        </div>
      </div>
    </div>
  );
};

const items = [
  {
    key: "1",
    label: "Quản lý lớp học",
    children: <ClassContent />,
  },
  {
    key: "2",
    label: "Lịch sử lớp học",
    children: <HistoryContent />,
  },
];

function ClassManagerment() {
  const [openClassModal, setOpenClassModal] = useState(false);
  const [openCourseModal, setOpenCourseModal] = useState(false);

  return (
    <Layout style={{ minHeight: "100vh", minWidth: "100vw", display: "flex" }}>
      <SideBar />
      <Layout style={{ flex: 1 }}>
        <div className="h-auto bg-gradient-to-br from-blue-50 to-indigo-50 p-6">
          <div className="flex justify-between items-center">
            <h1 className="text-indigo-900 font-bold text-3xl">
              Quản lý lớp học
            </h1>
            <div>
              <button
                onClick={() => setOpenClassModal(true)}
                className="bg-blue-500 w-32 text-white p-2.5 mt-2.5 mr-2.5 rounded-md"
              >
                Thêm Lớp
              </button>
              <AddClass open={openClassModal} setOpen={setOpenClassModal} />
              <button
                onClick={() => setOpenCourseModal(true)}
                className="bg-blue-500 w-32 text-white p-2.5 mt-2.5 rounded-md"
              >
                Thêm khóa học
              </button>
              <AddCourse open={openCourseModal} setOpen={setOpenCourseModal} />
            </div>
          </div>
          <div className="tab">
            <Tabs defaultActiveKey="1" items={items} />
          </div>
        </div>
      </Layout>
    </Layout>
  );
}

export default ClassManagerment;
