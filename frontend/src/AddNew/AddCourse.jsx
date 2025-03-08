import React, { useState } from "react";
import { Modal, Form, Input, message } from "antd";
import axios from "axios";

function AddCourse({ open, setOpen }) {
  const [confirmLoading, setConfirmLoading] = useState(false);
  const [form] = Form.useForm();

  const apiCourse = import.meta.env.VITE_API_COURSE;

  const createCourse = async (valuse) => {
    try {
      await axios.post(apiCourse, valuse);
      message.success("Thêm môn học thành công!");
      return true;
    } catch (error) {
      console.error("Validation failed:", error);
      message.error("Thêm môn học thất bại. Vui lòng thử lại!");
      return false;
    }
  };

  const handleOk = async () => {
    try {
      setConfirmLoading(true);

      const values = await form.validateFields();
      var result = { ...values, lecturerId: 1 };

      const isSuccess = await createCourse(result);

      if (isSuccess) {
        setConfirmLoading(false);
        setOpen(false);
        form.resetFields();
      }
    } catch (error) {
      console.log("Validation failed:", error);
    }
  };

  const handleCancel = () => {
    setOpen(false);
  };

  return (
    <Modal
      title="Thêm khóa học mới"
      open={open}
      onOk={handleOk}
      confirmLoading={confirmLoading}
      onCancel={handleCancel}
      okText={"Đăng ký"}
    >
      <Form
        form={form}
        name="addCourse"
        initialValues={{ remember: true }}
        style={{ maxWidth: 360, margin: "auto" }}
      >
        <Form.Item
          name="courseId"
          rules={[
            {
              required: true,
              message: "Vui lòng nhập mã khóa học!",
            },
          ]}
          style={{ marginBottom: "1rem" }}
        >
          <Input
            style={{ padding: "0.5rem" }}
            placeholder="Mã môn học"
            autoComplete="off"
          />
        </Form.Item>
        <Form.Item
          name="courseName"
          rules={[
            {
              required: true,
              message: "Vui lòng nhập tên khóa học!",
            },
          ]}
          style={{ marginBottom: "1rem" }}
        >
          <Input
            style={{ padding: "0.5rem" }}
            placeholder="Tên môn học"
            autoComplete="off"
          />
        </Form.Item>
      </Form>
    </Modal>
  );
}

export default AddCourse;
