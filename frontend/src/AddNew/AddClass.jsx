import React, { useEffect, useState } from "react";
import { Button, Modal, Form, Input, DatePicker, Select } from "antd";
import dayjs from "dayjs";

const dataRoom = [
  {
    value: 1,
    label: "A24.1",
  },
  {
    value: 2,
    label: "A8.5",
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

  const handleOk = () => {
    setModalText("The modal will be closed after two seconds");
    setConfirmLoading(true);
    setTimeout(() => {
      setOpen(false);
      setConfirmLoading(false);
    }, 2000);
  };

  const handleCancel = () => {
    console.log("Clicked cancel button");
    setOpen(false);
  };

  return (
    <>
      <Modal
        title="Thêm lớp học mới"
        open={open}
        onOk={handleOk}
        confirmLoading={confirmLoading}
        onCancel={handleCancel}
      >
        <Form
          name="add"
          initialValues={{
            remember: true,
          }}
          style={{
            maxWidth: 360,
            margin: "auto",
          }}
          // onFinish={onFinish}
        >
          <Form.Item
            name="className"
            rules={[
              {
                required: true,
                message: "Please input Class Name!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Input style={{ padding: "0.5rem" }} placeholder="Tên lớp" />
          </Form.Item>
          <Form.Item
            name="lecturerName"
            rules={[
              {
                required: true,
                message: "Please input Lecturer Name!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Input style={{ padding: "0.5rem" }} placeholder="Giảng viên" />
          </Form.Item>
          <Form.Item
            name="timeStudy"
            rules={[
              {
                required: true,
                message: "Please select study time!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <DatePicker
              style={{ width: "100%", height: "100%", padding: "0.5rem" }}
              format={"DD-MM-YYYY"}
              inputReadOnly={true}
              allowClear={false}
              defaultValue={dayjs("06-03-2025")}
            />
          </Form.Item>
          <Form.Item
            name="classRoom"
            rules={[
              {
                required: true,
                message: "Please select class room!",
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
                message: "Please select course!",
              },
            ]}
            style={{ marginBottom: "1rem" }}
          >
            <Select
              showSearch
              style={{ width: "100%", height: "100%" }}
              placeholder="Môn học"
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
