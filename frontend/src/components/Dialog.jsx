
//From https://dev.to/elsyng/react-modal-dialog-using-html-dialog-element-5afk
import { useEffect, useRef } from "react";
import styled from "styled-components";

const Container = styled.dialog`
  width: 400px;
  border-radius: 8px;
  border: 1px solid #888;

  ::backdrop {
    background: rgba(0, 0, 0, 0.3);
  }
`;

const Buttons = styled.div`
  display: flex;
  gap: 20px;
`;

const isClickInsideRectangle = (e, element) => {
  const r = element.getBoundingClientRect();

  return (
    e.clientX > r.left &&
    e.clientX < r.right &&
    e.clientY > r.top &&
    e.clientY < r.bottom
  );
};



const DialogModal = ({
  title,
  isOpened,
  onProceed,
  onClose,
  children,
  confirmText,
  onSubmit
}) => {
  const ref = useRef(null);

  useEffect(() => {
    if (isOpened) {
      ref.current?.showModal();
      document.body.classList.add("modal-open"); // prevent bg scroll
    } else {
      ref.current?.close();
      document.body.classList.remove("modal-open");
    }
  }, [isOpened]);

  const proceedAndClose = () => {
    onProceed();
    onClose();
  };

  return (
    <Container
      ref={ref}
      onCancel={onClose}
      onClick={(e) =>
        ref.current && !isClickInsideRectangle(e, ref.current) && onClose()
      }
    >
      <h4><b>{title}</b></h4>

      <form onSubmit={onSubmit}>
        {children}
        <Buttons className="w3-padding">
          <button className="w3-button w3-indigo" type="submit">{confirmText}</button>
          <button className="w3-button w3-red" onClick={(e)=>{
            e.preventDefault()
            onClose()
          }}>Close</button>
        </Buttons>
      </form>
    </Container>
  );
};

export default DialogModal;