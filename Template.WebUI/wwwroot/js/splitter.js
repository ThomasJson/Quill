(function () {
    window.initializeSplitter = function (splitterRef) {
        let isDragging = false;
        const leftPanel = splitterRef.previousElementSibling;
        const rightPanel = splitterRef.nextElementSibling;
        let startX, startWidthLeft, startWidthRight;

        splitterRef.onmousedown = function (e) {
            isDragging = true;
            startX = e.clientX;
            startWidthLeft = leftPanel.offsetWidth;
            startWidthRight = rightPanel.offsetWidth;

            document.addEventListener('mousemove', onMouseMove);
            document.addEventListener('mouseup', onMouseUp);

            function onMouseMove(e) {
                if (!isDragging) return;
                let dx = e.clientX - startX;
                let newLeftWidth = ((startWidthLeft + dx) * 100) / splitterRef.parentNode.offsetWidth;
                let newRightWidth = ((startWidthRight - dx) * 100) / splitterRef.parentNode.offsetWidth;
                
                newLeftWidth = Math.max(25, Math.min(newLeftWidth, 75));
                newRightWidth = Math.max(25, Math.min(newRightWidth, 75));
                
                newRightWidth = 100 - newLeftWidth;

                leftPanel.style.width = `${newLeftWidth}%`;
                rightPanel.style.width = `${newRightWidth}%`;
            }

            function onMouseUp() {
                if (isDragging) {
                    document.removeEventListener('mousemove', onMouseMove);
                    document.removeEventListener('mouseup', onMouseUp);
                    isDragging = false;
                }
            }
        };
    };
})();