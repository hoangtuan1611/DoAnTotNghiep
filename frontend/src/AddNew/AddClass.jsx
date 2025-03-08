import React, { useState } from "react";
import { Button, Modal, Form, Input, DatePicker, Select } from "antd";
import dayjs from "dayjs";
import axios from "axios";

const dataRoom = [
  {
    value: 1,
    label: "A24.1",
  },
  {
    value: 2,
    label: "A8.5",
  },
  {
    value: 3,
    label: "TV1",
  },
  {
    value: 4,
    label: "TV2",
  },
  {
    value: 5,
    label: "TV3",
  },
  {
    value: 6,
    label: "TV4",
  },
];

const dataCourse = [
  {
    value: 1,
    label: "Hướng đối tượng",
  },
  {
    value: 2,
    label: "Ứng dụng desktop",
  },
];

function AddClass({ open, setOpen }) {
  const [confirmLoading, setConfirmLoading] = useState(false);

  const apiCourse = import.meta.env.VITE_API_COURSE;
  const lecturerId = 1;

  const getAllCourse = () => {
    var apiQuery = `${api}/by-lecturer?lecturerId=${lecturerId}`;
    var result = axios.get();
  };

  // const handleOk = () => {
  //   setModalText("The modal will be closed after two seconds");
  //   setConfirmLoading(true);
  //   setTimeout(() => {
  //     setOpen(false);
  //     setConfirmLoading(false);
  //   }, 2000);
  // };

  const handleCancel = () => {
    console.log("Clicked cancel button");
    setOpen(false);
  };

  const onFinish = (values) => {
    // const data = {};
    console.log(values);
    setConfirmLoading(true);
    setTimeout(() => {
      setOpen(false);
      setConfirmLoading(false);
    }, 2000);
  };

  // Chua fix xong

  return (
    <>
      <Modal
        title="Thêm lớp học mới"
        open={open}
        // onOk={handleOk}
        confirmLoading={confirmLoading}
        onCancel={handleCancel}
      >
        <Form
          name="addClass"
          initialValues={{ remember: true }}
          style={{ maxWidth: 360, margin: "auto" }}
          onFinish={onFinish}
        >
          <Form.Item
            name="className"
            rules={[
              {
                required: true,
                message: "Vui lòng nhập tên lớp!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Input style={{ padding: "0.5rem" }} placeholder="Tên lớp" />
          </Form.Item>
          <Form.Item
            name="subLecturerName"
            rules={[
              {
                required: false,
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Input style={{ padding: "0.5rem" }} placeholder="Tên trợ giảng" />
          </Form.Item>
          <Form.Item
            name="timeStart"
            rules={[
              {
                required: true,
                message: "Vui lòng nhập giờ bắt đầu!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <DatePicker
              style={{ width: "100%", height: "100%", padding: "0.5rem" }}
              format={"DD-MM-YYYY"}
              inputReadOnly={true}
              allowClear={false}
              defaultValue={dayjs()}
            />
          </Form.Item>
          <Form.Item
            name="classRoom"
            rules={[
              {
                required: true,
                message: "Vui lòng chọn phòng học!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Select
              showSearch
              style={{ width: "100%", height: "100%" }}
              placeholder="Phòng học"
              optionFilterProp="label"
              filterSort={(a, b) => {
                (a?.label ?? "")
                  .toLowerCase()
                  .localeCompare((b?.label ?? "").toLowerCase());
              }}
              options={dataRoom}
            />
          </Form.Item>
          <Form.Item
            name="course"
            rules={[
              {
                required: true,
                message: "Vui lòng chọn khóa học!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Select
              showSearch
              style={{ width: "100%", height: "100%" }}
              placeholder="Khóa học"
              optionFilterProp="label"
              filterSort={(a, b) => {
                (a?.label ?? "")
                  .toLowerCase()
                  .localeCompare((b?.label ?? "").toLowerCase());
              }}
              options={dataCourse}
            />
          </Form.Item>
          <Form.Item>
            <Button block type="primary" htmlType="submit">
              Đăng ký
            </Button>
          </Form.Item>
        </Form>
      </Modal>
    </>
  );
}

export default AddClass;
