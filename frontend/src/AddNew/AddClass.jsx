import React, { useEffect, useState } from "react";
import {
  Modal,
  Form,
  Input,
  DatePicker,
  Select,
  InputNumber,
  message,
} from "antd";
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

function AddClass({ open, setOpen }) {
  const [confirmLoading, setConfirmLoading] = useState(false);
  const [dataCourse, setDataCourse] = useState([]);
  const [form] = Form.useForm();

  const apiCourse = import.meta.env.VITE_API_COURSE;
  const apiClass = import.meta.env.VITE_API_CLASS;
  const lecturerId = 1;

  const getAllCourse = async () => {
    var apiQuery = `${apiCourse}/by-lecturer?lecturerId=${lecturerId}`;
    var result = await axios.get(apiQuery);
    setDataCourse(result.data);
  };

  const createClass = async (valuse) => {
    try {
      await axios.post(apiClass, valuse, {
        headers: {
          "Content-Type": "application/json",
        },
      });
      message.success("Thêm lớp học thành công!");
      return true;
    } catch (error) {
      console.error("Validation failed:", error);
      message.error("Thêm lớp học thất bại. Vui lòng thử lại!");
      return false;
    }
  };

  const handleOk = async () => {
    try {
      setConfirmLoading(true);

      const values = await form.validateFields();

      console.log("Values from form:", values);

      const bodyClass = {
        classId: values.className,
        maxStudents: values.maxStudents,
        idCourse: values.course,
      };

      console.log("BodyClass being sent:", bodyClass);

      const isSuccess = await createClass(bodyClass);

      if (isSuccess) {
        setOpen(false);
        form.resetFields();
      }
    } catch (error) {
      console.log("Validation failed:", error);
    } finally {
      setConfirmLoading(false);
    }
  };

  const handleCancel = () => {
    console.log("Clicked cancel button");
    setOpen(false);
  };

  useEffect(() => {
    getAllCourse();
  }, []);

  return (
    <Modal
      title="Thêm lớp học mới"
      open={open}
      onOk={handleOk}
      confirmLoading={confirmLoading}
      onCancel={handleCancel}
      okText={"Đăng ký"}
    >
      <Form
        name="addClass"
        initialValues={{ remember: true }}
        style={{ maxWidth: 360, margin: "auto" }}
        form={form}
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
          name="maxStudents"
          rules={[
            {
              required: true,
              message: "Vui lòng nhập số sinh viên!",
            },
          ]}
          style={{ marginBottom: "1rem" }}
        >
          <InputNumber
            style={{ width: "100%", height: "100%", padding: "0.3rem" }}
            min={1}
            placeholder="Nhập số lượng sinh viên"
          />
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
            fieldNames={{ value: "id", label: "courseName" }}
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
      </Form>
    </Modal>
  );
}

export default AddClass;
